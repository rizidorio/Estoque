<template>
    <main class="container">
        <h3>Novo produto</h3>
        <form class="form" @submit.prevent="salvar">
            <input id="sku" name="sku" placeholder="SKU" type="text" class="form-control" v-model="product.sku"/>
            <input id="name" name="name" placeholder="Nome" type="text" class="form-control" v-model="product.name"/>
            <input id="description" name="description" placeholder="Descrição" type="text" class="form-control" v-model="product.description"/>
            <input id="category" name="category" placeholder="Categoria" type="text" class="form-control" v-model="product.category"/>
            <input id="cust" name="name" placeholder="Preço de custo" type="number" class="form-control" v-model="product.cust"/>
            <section class="d-flex justify-content-evenly">
                <button type="submit" class="btn btn-success">Salvar</button>
                <button v-on:click="goBack" class="btn btn-danger">Cancelar</button>
            </section>
        </form>
    </main>
</template>

<script>
import Product from '../services/produtos';

export default {
    name: 'NewProduct',
    data() {
        return {
            product: {
                sku: '',
                name: '',
                description: '',
                category: '',
                cust: '',
                quantity: 0,
            },
        }
    },
    methods: {
        salvar(){
            Product.salvar(this.product).then((response) => {
                console.log(response.data);
                this.$router.push('produtos')
            }).catch((err) => {
                console.log(err);
            });
        },
        goBack(){
            this.$router.push('produtos')
        }
    }
}
</script>

<style scoped>
    .form{
        display: inline-block;
        justify-content: center;
        width: 25rem;
        margin-top: 2rem;
    }

    input {
        margin-bottom: 1rem;
    }
</style>