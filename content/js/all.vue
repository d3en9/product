<template>
    <grid
        :data="gridData"
        :options="gridOptions"
        >
    </grid>
</template>


<script>
    import grid from "./grid.vue";
    import axios from 'axios';
    
    export default {
        name: 'all',
        data: function () {
            return {
                searchQuery: '',
                gridOptions: {
                    operation: false,
                    columns: [
                        { name: 'name', label: 'Name', type: 'string' }, 
                        { name: 'lastUpdated', label: 'Last updated', type: 'DateTime' },
                        { name: 'createrId', label: 'creater Id', type: 'string' }],
                }, 
                gridData: [],
                
            }            
        },
        mounted: function() {
            this.loadAllProducts();
        },
        methods: {
            loadAllProducts: function() {
                axios.get('/api/products')
                    .then(response => { this.gridData = response.data })
                    .catch(e => this.errors.push(e));
            }
        },
        components: {
            'grid': grid
        }
    };
</script>