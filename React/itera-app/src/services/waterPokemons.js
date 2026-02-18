import { HTTPClient } from "./client"

export default {
  obterPokemonsTipoAgua() {
    return HTTPClient.get("type/11")
  }
}