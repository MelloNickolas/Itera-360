import style from"./_Button.module.css";
import { useState } from "react";
import LogoAzul from "../../assets/LogoAzul.png";

const COLOR = {
  orange: style.orange,
  blue: style.blue
}

const SIZE = {
  small_size: style.small_size,
  medium_size: style.medium_size,
  large_size: style.large_size
}

export const Button = () => {
  return <button> Botão </button>
}


// Todos os componesntes que forem filhos "children" vão ser renderizados, e passados dentro dessa propriedade
export const ButtonProps = ({ children, label }) => {
  return <>
    <label>{label}</label>
    <button>{children}</button>
  </>
}

export const ButtonClick = ({ children, label, color, size }) => {
  function handleClick() {
    console.log(label)
  }
  return <>
    <label>{label}</label>
    <button onClick={handleClick} className={`${style.button_example} ${COLOR[color]} ${SIZE[size]}`}>{children}</button>
  </>
}

export const ButtonImage = ({ children, label, size, color }) => {
  const [showImage, setShowImage] = useState(false);

  function handleClick() {
    setShowImage(true);
  }
  return <>
    <label>{label}</label>
    <button onClick={handleClick} className={`${style.button_image} ${COLOR[color]} ${SIZE[size]}`}>{children}</button>

    {showImage && (
        <img src={LogoAzul} alt="Logo Azul" className={`${style.Image}`}/>
      )}
  </>
}
