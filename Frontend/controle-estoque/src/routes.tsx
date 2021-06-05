import React from 'react';
import { Route, BrowserRouter, Switch } from 'react-router-dom';

import Home from './pages/Home';
import Login from './pages/login';
const Routes = () => {
    return (
        <BrowserRouter>
            <Switch>
                <Route component={Login} path="/" exact/>
                <Route component={Home} path="/Home" />
            </Switch>
        </BrowserRouter>
    );
};

export default Routes;