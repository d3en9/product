import Vue from 'vue';
import ElementUI from 'element-ui';
import '../scss/app.scss';
import 'element-ui/lib/theme-chalk/index.css';
import locale from 'element-ui/lib/locale/lang/en';
import router from './router';


Vue.use(ElementUI, { locale });

var app = new Vue({
    el: '#app',
    router,
    data: {
        errors: []
    },
    components: {

    },
    computed: {
        route: function() {
            return this.$router.currentRoute.path;
        }
    },
    methods: {

    }
});