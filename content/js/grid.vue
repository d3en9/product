<template>
  <el-table
    :data="data"
    style="width: 100%">
    <el-table-column v-for="col in options.columns"
      :label="col.label" sortable prop="col.name">
      <template slot-scope="scope">
        <i v-if="col.type == 'DateTime'" class="el-icon-time"></i>
        <span style="margin-left: 10px">{{ scope.row[col.name] }}</span>
      </template>
    </el-table-column>
    
    <el-table-column v-if="options.operation"
      label="Operations">
      <template slot-scope="scope">
        <el-button
          size="mini"
          @click="handleEdit(scope.$index, scope.row)">Edit</el-button>
        <el-button
          size="mini"
          type="danger"
          @click="handleDelete(scope.$index, scope.row)">Delete</el-button>
      </template>
    </el-table-column>
  </el-table>
</template>


<script>
    export default {
        props: {
            data: Array,
            options: Object,
            
        },
        
        computed: {
            
        },
        filters: {
            
        },
        methods: {
            handleEdit(index, row) {
                this.$emit('edit', row);
            },
            handleDelete(index, row) {
                this.$emit('delete', row);
            }
        }

    };
</script>

<style>

th {
  cursor: pointer;
  -webkit-user-select: none;
  -moz-user-select: none;
  -ms-user-select: none;
  user-select: none;
}

th.active {
  color: #000;
}

th.active .arrow {
  opacity: 1;
}

.arrow {
  display: inline-block;
  vertical-align: middle;
  width: 0;
  height: 0;
  margin-left: 5px;
  opacity: 0.66;
}

.arrow.asc {
  border-left: 4px solid transparent;
  border-right: 4px solid transparent;
  border-bottom: 4px solid #000;
}

.arrow.dsc {
  border-left: 4px solid transparent;
  border-right: 4px solid transparent;
  border-top: 4px solid #000;
}
</style>