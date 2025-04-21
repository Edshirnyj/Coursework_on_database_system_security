import React from 'react';
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
import Header from './components/Header';
import Footer from './components/Footer';
import HomePage from './pages/HomePage';
import RolesPage from './pages/RolesPage';
import './styles/global.css';

const App: React.FC = () => {
    return (
        <Router>
            <div className="app-container">
                <Header />
                <Switch>
                    <Route path="/" exact component={HomePage} />
                    <Route path="/roles" component={RolesPage} />
                </Switch>
                <Footer />
            </div>
        </Router>
    );
};

export default App;