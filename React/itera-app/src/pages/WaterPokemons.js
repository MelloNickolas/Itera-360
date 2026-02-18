import { useEffect, useState } from "react";
import pokemonsTipoAgua from "../services/waterPokemons";

export const WaterPokemons = () => {
  const [lista, setLista] = useState([]);

  useEffect(() => {
    pokemonsTipoAgua.obterPokemonsTipoAgua()
      .then((response) => setLista(response.data.pokemon))
      .catch((err) => console.log(err));
  }, []);

  return (
    <div>
      {lista.map((item) => (
        <p key={item.pokemon.name}>{item.pokemon.name}</p>
      ))}
    </div>
  );
};
