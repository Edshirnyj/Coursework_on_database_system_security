import React from 'react';
import { Link } from 'react-router-dom';
import './global.css';

const Header: React.FC = () => {
    return (
        <header className="header">
            <nav className="navbar">
                <ul className="nav-links">
                    <li>
                        <Link to="/">Home</Link>
                    </li>
                    <li>
                        <Link to="/roles">Roles</Link>
                    </li>
                </ul>
            </nav>
        </header>
    );
};

export default Header;