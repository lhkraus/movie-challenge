import React from 'react';
import { Card as AntdCard, Tag } from 'antd';

import './index.css'

const Card = ({ title, posterUrl, genres, releaseDate }) => (
    <AntdCard
        hoverable
        className="card"
        cover={<img alt={title} src={posterUrl} />}
    >
        <AntdCard.Meta title={title} />
        <span>Release Date: {releaseDate}</span>
        {genres && genres.map(genre => <Tag>{genre.name}</Tag>)}
    </AntdCard>
)

export { Card }