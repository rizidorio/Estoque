import { api } from "./config";

export default {
    listarProdutos:() => {
        return api.get('product');
    },

    salvar:(product) => {
        return api.post('product', product);
    },
}