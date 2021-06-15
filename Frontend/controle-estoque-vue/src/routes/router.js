import Vue from 'vue';
import VueRouter from 'vue-router';
import Home from '../pages/Home.vue';
import Products from '../pages/Products.vue';
import NewProduct from '../pages/NewProduct.vue';

Vue.use(VueRouter);

const routes = [
    { path: '/', component: Home },
    { path: '/produtos', component: Products },
    { path: '/newProduct', component: NewProduct },
];

const router = new VueRouter({
    routes,
    mode:'history'
});

export default router;