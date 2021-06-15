<template>
    <main class="container">
        <div class="row">
            <div class="col-md-4">
                <article id="card1" class="card border-primary">
                    <section class="card-header">Produtos</section>
                    <section class="body card-body text-primary">
                        <a href="/produtos" class="btn btn-outline-primary">Listar produtos</a>
                        <a href="/newProduct" class="btn btn-outline-primary">Novo produto</a>
                    </section>
                </article>
            </div>
            <div class="col-md-4">
                <article id="card2" class="card border-warning">
                    <section class="card-header">Usuários</section>
                    <section class="body card-body text-warning">
                        <a href="/produtos" class="btn btn-outline-warning">Listar usuários</a>
                        <a href="/" class="btn btn-outline-warning">Novo usuário</a>
                    </section>
                </article>
            </div>
            <div class="col-md-4">
                <article id="card3" class="card border-success">
                    <section class="card-header">Lançamentos</section>
                    <section class="body card-body text-success">
                        <a href="/produtos" class="btn btn-outline-success">Listar lançamentos</a>
                        <a href="/" class="btn btn-outline-success">Novo lançamento</a>
                    </section>
                </article>
            </div>
        </div>
    </main>
</template>

<script>
    export default {
        name: 'Home'
    }
</script>

<style scoped>
    .body {
        display: flex;
        justify-content: space-between;
    }
</style>