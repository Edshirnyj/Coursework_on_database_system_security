import React from 'react';
import './glassmorphism.css';

const GlassCard: React.FC<{ title: string; content: string }> = ({ title, content }) => {
    return (
        <div className="glass-card">
            <h2>{title}</h2>
            <p>{content}</p>
        </div>
    );
};

export default GlassCard;