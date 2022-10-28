import React, { Component } from 'react'
import { BrowserRouter, Route } from "react-router-dom";
import NavBar from './components/Navigators/NavBar';

export default class MainRouter extends Component {
  render() {
    return (
      <div>
        <BrowserRouter>		
        <NavBar/>		
        </BrowserRouter>
      </div>
    )
  }
}
