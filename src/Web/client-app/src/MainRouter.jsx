import React, { Component } from "react";
import { BrowserRouter, Route } from "react-router-dom";

import NavBar from "./components/Navigators/NavBar";
import { Authentication } from "./pages/authentication/authentication";
import { Order } from "./pages/order/order";
import Approve from "./components/Approve Quotation/Approve";

export default class MainRouter extends Component {
  render() {
    return (
        <BrowserRouter>
          <div>
          <NavBar />
          {/* <Order></Order> */}



        <Route path="/approve" exact component={Approve}></Route>
        </div>
       
        </BrowserRouter>
      
    );
  }
}
