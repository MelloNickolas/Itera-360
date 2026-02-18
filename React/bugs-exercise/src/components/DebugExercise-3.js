const DebugExercise4 = () => {
  const nome = "Aluno"

  return (
    <div>
      <h1>Exercício de Depuração 4</h1>
      <p>Olá, {nome}</p>
      <button onClick={() => alert("Erro de sintaxe identificado!")}> Clique aqui
      </button>
    </div>
  )
}

export default DebugExercise4;