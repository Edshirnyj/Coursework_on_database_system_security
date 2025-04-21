import React from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import AdminPage from './pages/AdminPage';

const App = () => {
    return (
        <Router>
            <Routes>
                <Route path="/" element={<AdminPage />} />
            </Routes>
        </Router>
    );
};

export default App;