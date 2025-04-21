import React, { useState } from 'react';
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
import AdminLogin from './components/AdminLogin';
import Dashboard from './components/Dashboard';

const App: React.FC = () => {
  const [isLoggedIn, setIsLoggedIn] = useState(false);

  const handleLoginSuccess = () => {
    setIsLoggedIn(true);
  };

  return (
    <Router>
      <Switch>
        <Route path="/" exact>
          {isLoggedIn ? <Dashboard /> : <AdminLogin onLoginSuccess={handleLoginSuccess} />}
        </Route>
      </Switch>
    </Router>
  );
};

export default App;