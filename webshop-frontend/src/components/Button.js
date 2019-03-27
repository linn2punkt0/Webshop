import styled from "styled-components";

const Button = styled.button`
  max-width: 300px;
  height: 50px;
  margin: 0 10px 10px 10px;
  padding: 10px 10px 10px 10px;
  color: white;
  font-size: 15px;
  font-weight: 700;
  background: black;
  border-radius: 10px;
  border: none;
  box-shadow: 2px 2px 0px 0px #545454;
  transition: 0.3s ease-in;
  z-index: 5;

  &:hover {
    background: dodgerblue;
    box-shadow: 2px 2px 0px 0px black;
  }
`;

export default Button;
