import React from 'react';
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
import AdminPage from './components/Admin/AdminPage';
import SalesmanPage from './components/Salesman/SalesmanPage';
import UserPage from './components/User/UserPage';

const App: React.FC = () => {
    return (
        <Router>
            <Switch>
                <Route path="/admin" component={AdminPage} />
                <Route path="/salesman" component={SalesmanPage} />
                <Route path="/user" component={UserPage} />
                <Route path="/" exact>
                    <h1>Welcome to the Application</h1>
                </Route>
            </Switch>
        </Router>
    );
};

export default App;