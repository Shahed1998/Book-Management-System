import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  activeNavLink(event: any)
  {
    let navLinks = document.querySelectorAll('.nav-link');
    navLinks.forEach(links => links.classList.remove('active'))
    event.target.classList.add('active')
  }

  activeNavBrand()
  {
    var navLinks = document.querySelectorAll('.nav-link')
    navLinks.forEach(links => links.classList.remove('active'))
    navLinks[0].classList.add('active')
  }

}

