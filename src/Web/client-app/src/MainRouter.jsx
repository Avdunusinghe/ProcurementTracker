import React, { Component } from "react";
import { BrowserRouter, Route } from "react-router-dom";

import NavBar from "./components/Navigators/NavBar";
import { Authentication } from "./pages/authentication/authentication";
import { Order } from "./pages/order/order";
import Approve from "./components/ApproveQuotation/Approve";
import pendingQuatation from "./pages/quatation/pendingQuatation";


export default class MainRouter extends Component {
  render() {
    return (
        <BrowserRouter>
          <div>
          <NavBar />
        <Route path="/approve" exact component={Approve}></Route>
        </div>
       
          <Route path="/" exact component={Order} />
          <Route path="/quotation" exact component={pendingQuatation} />

        </BrowserRouter>
      
    );
  }
}
