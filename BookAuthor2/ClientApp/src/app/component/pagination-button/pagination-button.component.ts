import { ApiService } from 'src/app/api.service';
import { Router } from '@angular/router';
import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-pagination-button',
  templateUrl: './pagination-button.component.html',
  styleUrls: ['./pagination-button.component.css']
})
export class PaginationButtonComponent implements OnInit {

  // Checks if the page number is greater than 1
  // if it is greater than 1, then the back button will be enabled
  // if the page number passed is less than 1 then display the value of the button to 1, and display it's content
  // if the page number is greater than the available data then block the next key
  // if the back button is hit and next data is available then enable the next key

  currentPageNo = 1

  @Input() parent = ''
  @Input() nextCount!: Number
  @Input() page: any

  constructor(private router: Router) { }

  ngOnInit(): void {

    this.currentPageNo = this.page

    if(this.currentPageNo > 1)
    {
      (<HTMLButtonElement>document.getElementById("backBtn")).removeAttribute("disabled")
    }
    else if(this.currentPageNo <= 1)
    {
      this.currentPageNo = 1;
      (<HTMLButtonElement>document.getElementById("backBtn")).setAttribute("disabled", '')
    }

    if(!Math.ceil(Number(this.nextCount)/10))
    {
      if (this.parent === 'book') { this.router.navigate(['books'], {queryParams: {page: 1}});}
      else if (this.parent === 'publisher') { this.router.navigate(['publishers'], {queryParams: {page: 1}}); }
      else if (this.parent === 'author') { this.router.navigate(['authors'], {queryParams: {page: 1}}); }

      this.currentPageNo = 1;
      (<HTMLButtonElement>document.getElementById("backBtn")).setAttribute("disabled", "")
    }
  }

  btnNext()
  {
    this.currentPageNo++

    if(this.currentPageNo > 1){ (<HTMLButtonElement>document.getElementById("backBtn")).removeAttribute("disabled") }
    
    if(this.currentPageNo > Math.ceil(Number(this.nextCount)/10))
    {
      (<HTMLButtonElement>document.getElementById("nextBtn")).setAttribute("disabled", "")
      this.currentPageNo = Math.ceil(Number(this.nextCount)/10)
    }
    else if(this.parent === 'book')
    {
      this.router.navigate(['/books'], {queryParams: {page: this.currentPageNo}})
    }
    else if(this.parent === 'publisher')
    {
      this.router.navigate(['/publishers'], {queryParams: {page: this.currentPageNo}})
    }
    else if(this.parent === 'author')
    {
      this.router.navigate(['/authors'], {queryParams: {page: this.currentPageNo}})
    }
  }

  btnPrev()
  {
    (<HTMLButtonElement>document.getElementById("nextBtn")).removeAttribute("disabled")

    if (this.currentPageNo <= 1) 
    {
      this.currentPageNo == 1
    }
    else
    {
      this.currentPageNo--

      if(this.currentPageNo == 1){
        (<HTMLButtonElement>document.getElementById("backBtn")).setAttribute("disabled", '')
      }

      if(this.parent === 'book')
      {
        this.router.navigate(['/books'], {queryParams: {page: this.currentPageNo}})
      }
      else if (this.parent === 'publisher')
      {
        this.router.navigate(['/publishers'], {queryParams: {page: this.currentPageNo}})
      }
      else if (this.parent === 'author')
      {
        this.router.navigate(['/authors'], {queryParams: {page: this.currentPageNo}})
      }
    }
  }
}
