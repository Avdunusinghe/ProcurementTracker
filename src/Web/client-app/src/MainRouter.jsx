import React, { Component } from "react";
import { BrowserRouter, Route } from "react-router-dom";
import NavBar from "./components/Navigators/NavBar";
import { Authentication } from "./pages/authentication/authentication";
import { Order } from "./pages/order/order";

export default class MainRouter extends Component {
  render() {
    return (
      <div>
        <BrowserRouter>
          <NavBar />
          <Order></Order>
        </BrowserRouter>
      </div>
    );
  }
}
