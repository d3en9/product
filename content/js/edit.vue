<template>
    <el-dialog
        title="Edit product"
        :visible.sync="visible"
        width="60%"
        :before-close="handleClose">
        <div class="input-suffix">
            <span class="input-label">Name:</span>
            <el-input placeholder="Name" v-model="product.name"></el-input>
        </div>
        <span slot="footer" class="dialog-footer">
            <el-button @click="visible = false">Cancel</el-button>
            <el-button type="primary" @click="handleOk">Ok</el-button>
        </span>
    </el-dialog>
</template>

<script>
    import axios from 'axios';

    export default {
        data() {
            return {
                visible: false,
                product: {}
            }
        },
        mounted() {
            this.$parent.$on('showEdit', function (data) {
                this.product = data;
                console.log(this.product);
                this.visible = true;
                
            }.bind(this))
        },
        methods: {
            handleClose(done) {
                this.$confirm('Are you sure to close this dialog?')
                .then(_ => {
                    done();
                })
                .catch(_ => {});
            },
            handleOk() {
                var vm = this;
                axios.post('/api/products', this.product)
                .then(function ({data}) {
                    console.log(data);
                    vm.product.name = data.name;
                    vm.product.lastUpdated = data.lastUpdated;
                })
                .catch(function (e) {
                    console.log(e);
                });
            }
        },
        
    };
</script>