import React from 'react';
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
import CatalogPage from './pages/CatalogPage';

const App: React.FC = () => {
  return (
    <Router>
      <Switch>
        <Route path="/" component={CatalogPage} />
      </Switch>
    </Router>
  );
};

export default App;