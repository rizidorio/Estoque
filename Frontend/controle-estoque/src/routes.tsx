import React from 'react';
import { Route, BrowserRouter, Switch, Redirect } from 'react-router-dom';

import Home from './pages/Home';
import Login from './pages/Login';
import Users from './pages/Users/allUsers';
import NewUser from './pages/Users/newUser';
import EditUser from './pages/Users/editUser';
import Products from './pages/Products/allProducts';
import NewProduct from './pages/Products/newProduct';
import EditProduct from './pages/Products/editProduct';
import Movements from './pages/Movements/allMovements';
import NewMovement from './pages/Movements/newMovement';

interface PrivateRouteProps {
    component: any;
    path: any;
}

const PrivateRoute = (props: PrivateRouteProps) => {
    const { component: Component, ...rest} = props;
    return (
        <Route {...rest} render={props =>
            sessionStorage.getItem('login') 
            ? (<Component {...props} />) 
            : (<Redirect to={{ pathname: "/", state: { from: props.location } }}/>)
        }/>
    ); 
};

const Routes = () => {
    return (
        <BrowserRouter>
            <Switch>
                <Route component={Login} path="/" exact/>
                <Route component={NewUser} path="/newUser" exact/>
                <PrivateRoute component={Home} path="/Home" />
                <PrivateRoute component={Users} path="/users" />
                <PrivateRoute component={EditUser} path="/editUser" />
                <PrivateRoute component={Products} path="/products" />
                <PrivateRoute component={NewProduct} path="/newProduct" />
                <PrivateRoute component={EditProduct} path="/editProduct" />
                <PrivateRoute component={Movements} path="/movements" />
                <PrivateRoute component={NewMovement} path="/newMovement" />
            </Switch>
        </BrowserRouter>
    );
};

export default Routes;