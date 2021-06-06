import React from 'react';
import { Route, BrowserRouter, Switch, Redirect } from 'react-router-dom';

import Home from './pages/Home';
import Login from './pages/Login';
import NewUser from './pages/Users/user';
import Users from './pages/Users/allUsers';
import Categories from './pages/Categories/allCategories';
import NewCategory from './pages/Categories/newEditCategory';
import Measures from './pages/Measures/allMeasures';
import NewMeasures from './pages/Measures/newEditMeasures';
import Products from './pages/Products/allProducts';
import NewProduct from './pages/Products/newEditProduct';

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
                <PrivateRoute component={Categories} path="/categories" />
                <PrivateRoute component={NewCategory} path="/newCategory" />
                <PrivateRoute component={Measures} path="/measures" />
                <PrivateRoute component={NewMeasures} path="/newMeasures" />
                <PrivateRoute component={Products} path="/products" />
                <PrivateRoute component={NewProduct} path="/newProduct" />
            </Switch>
        </BrowserRouter>
    );
};

export default Routes;