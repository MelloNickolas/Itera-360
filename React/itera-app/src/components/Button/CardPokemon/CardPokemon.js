import style from './_cardPokemon.module.css'

//props datsa que estamos passsando o pokemon que pegamos
export const CardPokemon = ({ data }) => {
  return <> <div className={style.wrapper}>
    <div className={style.header}>
      <img src={data?.sprites?.front_default} />
      <h2>{data.name} <span>n - {data.id}</span></h2>
    </div>
    <hr />

    <div className={style.row}>
      <div>
        <div className={style.row}>
          {data?.types?.map((item, key) => <p key={key}>{item.type.name}</p>)}
        </div>

        <p><b>Experiencia Base: </b>{data.base_experience}</p>
        <p><b>Altura: </b>{data.height}</p>
        <p><b>Peso: </b>{data.weight}</p>
      </div>

      <div>
        {data?.stats?.map((item, key) => <p key={key}><b>{item.stat.name}:</b> {item.base_stat}</p>)}
      </div>
    </div>

  </div>
  </>
}