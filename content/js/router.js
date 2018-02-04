import Vue from 'vue';
import Router from 'vue-router';
import all from './all.vue';
import my from './my.vue';

Vue.use(Router);

export default new Router({
    routes: [{
        path: '/',
        name: 'all',
        component: all
    }, {
        path: '/my',
        name: 'my',
        component: my
    }]
});