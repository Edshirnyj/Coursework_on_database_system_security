import React from 'react';
import { Link } from 'react-router-dom';
import './styles/global.css';

const Header: React.FC = () => {
    return (
        <header className="glassmorphism rounded p-4">
            <nav>
                <ul className="flex justify-around">
                    <li>
                        <Link to="/">Home</Link>
                    </li>
                    <li>
                        <Link to="/about">About</Link>
                    </li>
                </ul>
            </nav>
        </header>
    );
};

export default Header;