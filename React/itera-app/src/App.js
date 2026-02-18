import logo from './logo.svg';
import './App.css';
import { Button, ButtonClick, ButtonImage, ButtonProps } from './components/Button/Button';

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <Button/>

        <ButtonProps label='Minha Label'>
          Botão Teste
        </ButtonProps>

        <ButtonClick label='TESTE' color='blue' size='small_size'>
          Teste de Click
        </ButtonClick>

        <ButtonImage label="Teste da imagems" color='orange' size='large_size'>
          Ver Imagem
        </ButtonImage>
      </header>
    </div>
  );
}

export default App;
