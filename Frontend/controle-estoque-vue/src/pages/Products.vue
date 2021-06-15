<template>
  <main class="container">
    <section class="d-flex align-items-start flex-column bd-highlight mb-3">
      <h3>Produtos</h3>
      <a href="/newProduct" class="btn btn-success">Novo produto</a>
    </section>
    
    <table class="table table-striped">
        <thead>
          <tr>
            <th scope="col">SKU</th>
            <th scope="col">Produto</th>
            <th scope="col">Descrição</th>
            <th scope="col">Custo</th>
            <th scope="col">Qtde</th>
            <th></th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="produto of produtos" :key="produto.id">
            <td>{{ produto.sku }}</td>
            <td>{{ produto.name }}</td>
            <td>{{ produto.description }}</td>
            <td>R$ {{ produto.cust }}</td>
            <td>{{ produto.quantity }}</td>
            <td class="buttons">
              <a href="/" class="btn btn-primary">Editar</a>
              <a href="/" class="btn btn-danger">Apagar</a>
            </td>
          </tr>
        </tbody>
      </table>
  </main>
</template>

<script>
import Product from '../services/produtos';

export default {
  data(){
    return {
      produtos: []
    }
  },
  mounted(){
    Product.listarProdutos().then(response => {
      this.produtos = response.data;
      console.log(this.produtos);
    })
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
  .buttons {
    display: flex;
    justify-content: space-evenly;
  }
</style>
