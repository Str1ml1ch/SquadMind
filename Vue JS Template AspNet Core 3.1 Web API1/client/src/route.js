import vue from 'vue'
import Route from 'vue-router'

vue.use(Route)

export default new Route({
    mode: 'history',
    routes: [{
            path: '/user/:id',
            component: () =>
                import ('./components/HelloWorld.vue')
        },
        {
            path: '/',
            component: () =>
                import ('./components/HelloWorld.vue')
        },
        {
            path: '/user/:id/:type',
            component: () =>
                import ('./components/HelloWorld.vue'),

        }
    ]
})