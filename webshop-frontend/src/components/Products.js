import styled from "styled-components";
import React from "react";
import Button from "./Button.js";

const StyledProducts = styled.div`
  width: auto;
  margin: 5px;
  padding: 5px;
  font-size: 15px;
  background: white;
  color: black;
  border-radius: 10px;
  border: 1px solid grey;

  h4 {
    margin: 0;
    padding: 10px;
    font-size: 20px;
  }
  img {
    height: 30vh;
  }
  h6 {
    font-size: 15px;
  }
  div {
    display: flex;
    flex-direction: row;
    justify-content: space-between;
    align-items: center;
    padding: 10px;
  }
`;

const Products = props => {
  return (
    <StyledProducts>
      <h4>{props.product.name}</h4>
      <img src={props.product.img_url} alt="product" />
      <p>{props.product.description}</p>
      <div>
        <h6>{props.product.price}kr</h6>
        <h6>{props.product.size}cl</h6>
      </div>
      <Button onClick={() => props.addToCart(0, props.product.id)}>
        Add to cart
      </Button>
    </StyledProducts>
  );
};

export default Products;
