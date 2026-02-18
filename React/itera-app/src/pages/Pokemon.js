import { useEffect, useState } from "react"
import pokemon from "../services/pokemon"
import { CardPokemon } from "../components/Button/CardPokemon/CardPokemon"
import style from './_pokemon.module.css';

// export const Pokemon = () => {
//   const [charizard, setCharizard] = useState({})

//   useEffect(() => {
//     pokemon.obterPokemon('charizard')
//       .then((response) => setCharizard(response.data))
//       .catch((err) => console.log(err))
//   }, [])
//   return <div>
//     <h2>Pokemon charizard</h2>
//     <img src={charizard?.sprites?.front_default}/>
//     <p>{charizard?.name}</p>
//   </div>
// }









// export const Pokemon = () => {
//   const [pokemonSearch, setPokemonSearch] = useState("")
//   const [pokemonData, setPokemonData] = useState(null)

//   function buscarPokemon() {
//     pokemon.obterPokemon(pokemonSearch.toLowerCase())
//       .then((response) => setPokemonData(response.data))
//       .catch((err) => {
//         console.log(err)
//         setPokemonData(null)
//       })
//   }

//   //colocamos o botao pois so vamos chamar a API quando apertarmos ele.

//   return <div>
//     <label>Buscar Pokemon :</label>
//     <input type="text" placeholder="Digite o nome do Pokemon" value={pokemonSearch} onChange={(e) => setPokemonSearch(e.target.value)} />

//     <button onClick={buscarPokemon}>Buscar</button>

//     {pokemonData && (
//       <div>
//         <h3>{pokemonData.name}</h3>
//         <img src={pokemonData?.sprites?.front_default} />
//       </div>
//     )}
//   </div>
// }




export const Pokemon = () => {
  const [pokemonAtivo, setPokemonAtivo] = useState({})

  useEffect(() => {
    pokemon.obterPokemon('mewtwo')
    .then((response) => setPokemonAtivo(response.data))
    .catch((err) => console.log(err))
  })

  return <>
  <div className={style.wrapper}>
    <CardPokemon data={pokemonAtivo}/>
  </div>
  </>
}