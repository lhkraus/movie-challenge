import React, { useState, useEffect } from 'react';
import { useBottomScrollListener } from 'react-bottom-scroll-listener';
import { Layout, Menu, Input } from 'antd';
import { Card } from './components/card';

const { Header, Content, Footer } = Layout;

const App = () => {
  const [search, setSearch] = useState('');
  const [genres, setGenres] = useState([]);
  const [movies, setMovies] = useState([]);
  const [page, setPage] = useState(1);

  useEffect(() => {
    const fetchGenres = async () => {
      fetch('https://localhost:5001/api/genre/movie/list/')
        .then(response => response.json())
        .then(data => setGenres(data));
    };

    fetchGenres();
  }, [])

  useEffect(() => {
    window.scrollTo(0, 0);
    setMovies([]);
    setPage(1);

    const fetchMovies = async () => {
      if (search) {
        fetch(`https://localhost:5001/api/movie/search/${page}?title=${search}`)
          .then(response => response.json())
          .then(data => setMovies(data));
      } else {
        fetch(`https://localhost:5001/api/movie/upcoming/${page}`)
          .then(response => response.json())
          .then(data => setMovies(data));
      }
    };

    fetchMovies();

  }, [search]);

  useEffect(() => {
    const fetchMovies = async () => {
      if (search) {
        fetch(`https://localhost:5001/api/movie/search/${page}?title=${search}`)
          .then(response => response.json())
          .then(data => setMovies(movies.concat(data)));
      } else {
        fetch(`https://localhost:5001/api/movie/upcoming/${page}`)
          .then(response => response.json())
          .then(data => setMovies(movies.concat(data)));
      }
    };

    fetchMovies();
  }, [page])
  
  useBottomScrollListener(() => setPage(page + 1));

  const mapGenres = (movieGenres) => {
    return movieGenres.map(movieGenre => genres.find(genre => genre.id == movieGenre))
  }

  return (
    <Layout style={{ height: '100%' }}>
    <Header style={{ position: 'fixed', zIndex: 1, width: '100%' }}>
      <Menu
        theme="dark"
        mode="horizontal"
        defaultSelectedKeys={['1']}
        style={{ lineHeight: '64px' }}
      >
        <Input.Search
          placeholder="search by movie name"
          onSearch={value => setSearch(value)}
          style={{ width: 300 }}
        />
      </Menu>
    </Header>
    <Content style={{ padding: '0 50px', marginTop: 100 }}>
      
      <div style={{ background: '#fff', height: 'auto', padding: '20px', display: 'flex', flexDirection: 'row', flexWrap: 'wrap', justifyContent: 'center'}}>  
        {
          movies && movies.map(movie =>
            <Card
              key={movie.id}
              title={movie.title}
              releaseDate={movie.releaseDate}
              genres={mapGenres(movie.genres)}
              posterUrl={`https://image.tmdb.org/t/p/w500/${movie.poster}`}
            />
          )
        }
      </div>
    </Content>
    <Footer style={{ textAlign: 'center' }}>The Movie Database</Footer>
  </Layout>)
};

export { App };
