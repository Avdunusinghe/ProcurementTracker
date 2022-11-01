import React, { Component } from 'react'
import avatar from '../../img/avatar.png'
import './NavBar.css'
import logo from '../../img/logo.png'

export default class NavBar extends Component {
  render() {
    return (
      <div className='head'>
		<div className='text-center'>
			<img src={logo} className='sameline' style={{height:'50px'}}></img>
			<h2 className='sameline'>iConstruct</h2>	
		</div>		
        <nav class="navbar navbar-expand-lg bg-primary">
			
					<div class="container-fluid">
				
						<a class="navbar-brand" href="#"></a>
						<button
							class="navbar-toggler"
							type="button"
							data-bs-toggle="collapse"
							data-bs-target="#navbarNavAltMarkup"
							aria-controls="navbarNavAltMarkup"
							aria-expanded="false"
							aria-label="Toggle navigation"
						>
							<span class="navbar-toggler-icon"></span>
						</button>
						<div class="collapse navbar-collapse" id="navbarNavAltMarkup">
							<div class="navbar-nav">
								<a class="nav-link active" style={{color:'white'}} aria-current="page" href="/">
									Home
								</a>
								<a class="nav-link"  style={{color:'white'}}  href="#">
									Orders
								</a>
								<a class="nav-link"  style={{color:'white'}}  href="/quatation">
									Quatation
								</a>
								<a class="nav-link"  style={{color:'white'}} >Contact Us</a>
							</div>
						</div>
						

						
							{" "}
							{/* href="/Profile" */}
						 <img src={avatar} style={{ width: "50px", height: "50px" }} />
						

						<form class="form-inline my-2 my-lg-0" >
							<a class="nav-link" href="" >
							
								&nbsp; Sign in &nbsp;
							</a>
						</form>
					</div>
				</nav>
      </div>
    )
  }
}
