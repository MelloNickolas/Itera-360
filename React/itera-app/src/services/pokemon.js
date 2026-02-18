import { HTTPClient } from "./client"

export default {
  obterPokemon(nome) {
    return HTTPClient.get(`pokemon/${nome}`)
  }
}