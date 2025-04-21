import React from 'react';
import './glassmorphism.css';

const Footer: React.FC = () => {
    return (
        <footer className="glass-card">
            <div className="footer-content">
                <p>&copy; {new Date().getFullYear()} Your Company. All rights reserved.</p>
                <p>Follow us on social media!</p>
            </div>
        </footer>
    );
};

export default Footer;