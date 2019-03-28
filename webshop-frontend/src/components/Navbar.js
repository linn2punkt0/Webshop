import React from "react";
import styled from "styled-components";
import { Link } from "@reach/router";

const StyledNavbar = styled.div`
  width: 96vw;
  height: 100px;
  margin-bottom: 20px;
  a {
    color: black;
    text-decoration: none;
    font-weight: 700;
    font-size: 30px;

    &:hover {
      color: #4a97bd;
    }
  }

  h2 {
    text-shadow: 2px 2px #4a97bd;
    margin: 0;
    margin-left: 10px;
  }

  @media screen and (min-width: 800px) {
    display: flex;
    flex-direction: row;
    justify-content: space-between;
    align-items: flex-end;
    font-size: 40px;
  }
`;

const Navbar = () => {
  return (
    <StyledNavbar>
      {" "}
      <h2>Gin-shop</h2>
      <Link to="/products">Products</Link>
      <Link to="/cart">Cart</Link>
    </StyledNavbar>
  );
};

export default Navbar;
