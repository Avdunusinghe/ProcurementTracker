import React, { Component } from "react";
import { BrowserRouter, Route } from "react-router-dom";
import NavBar from "./components/Navigators/NavBar";
import { Authentication } from "./pages/authentication/authentication";
import { Order } from "./pages/order/order";
import pendingQuatation from "./pages/quatation/pendingQuatation";

export default class MainRouter extends Component {
  render() {
    return (
      <div>
        <BrowserRouter>
          <NavBar />
          <Route path="/" exact component={Order} />
          <Route path="/quatation" exact component={pendingQuatation} />
        </BrowserRouter>
      </div>
    );
  }
}
