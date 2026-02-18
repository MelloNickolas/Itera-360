import './App.css';
import { useEffect, useState } from 'react';
  
function App() {
  const [valor, setValor] = useState("Olá");

  useEffect(() => {
    setTimeout(() => {
        setValor("Já se passaram 2 segundos!")
    }, 2000)
  }, []);



  return (
    <div className="App">
      <header className="App-header">
        <h2>{valor}</h2>
      </header>
    </div>
  );
}

export default App;
