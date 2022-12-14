import React, { Component } from "react";
import { BrowserRouter, Route } from "react-router-dom";

import NavBar from "./components/Navigators/NavBar";
import { Authentication } from "./pages/authentication/authentication";
import { Order } from "./pages/order/order";
import Approve from "./components/ApproveQuotation/Approve";
import pendingQuatation from "./pages/quatation/pendingQuatation";
import QuatationRequests from "./pages/quatation/quatationRequests";
import emailer from "./components/ApproveQuotation/Quotationapprove";
export default class MainRouter extends Component {
  render() {
    return (
      <BrowserRouter>
        <div>
          <NavBar />

       
        <Route path="/approve/:id" exact component={Approve}></Route>
        

        <Route path="/" exact component={Authentication} />
        <Route path="/Order" exact component={Order} />
        <Route path="/quatation" exact component={pendingQuatation} />
        <Route path="/quatationRequests" exact component={QuatationRequests} />
        <Route path="/email" exact component={emailer} />

        </div>
      </BrowserRouter>
       
     
      
      
    );
  }
}
