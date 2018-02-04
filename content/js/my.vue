<template>
    <div>
        <el-button type="primary">Add</el-button>
        <grid
            :data="gridData"
            :options="gridOptions"
            @delete="onDelete"
            @edit="onEdit">
        </grid>
        <edit-view></edit-view>
    </div>
</template>


<script>
    import grid from "./grid.vue";
    import edit from "./edit.vue";
    import axios from 'axios';
    
    export default {
        name: 'all',
        data: function () {
            return {
                searchQuery: '',
                gridOptions: {
                    operation: true,
                    columns: [
                        { name: 'id', label: '#', type: 'int' }, 
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
            },
            onDelete(row) {
                axios.delete(`/api/products?id=${row.id}`)
                    .then(function (response) {
                        this.loadAllProducts();
                    }.bind(this));
            },
            onEdit(row) {
                this.$emit('showEdit', row);
            }
        },
        components: {
            'grid': grid,
            'edit-view': edit
        }
    };
</script>