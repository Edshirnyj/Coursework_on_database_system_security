import React from 'react';
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
import LoginForm from './components/LoginForm';
import WorkspaceForm from './components/WorkspaceForm';
import Dashboard from './components/Dashboard';
import { AuthProvider } from './context/AuthContext';

const App = () => {
    return (
        <AuthProvider>
            <Router>
                <Switch>
                    <Route path="/" exact component={LoginForm} />
                    <Route path="/workspace" component={WorkspaceForm} />
                    <Route path="/dashboard" component={Dashboard} />
                </Switch>
            </Router>
        </AuthProvider>
    );
};

export default App;