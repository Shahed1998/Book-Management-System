import { ActivatedRoute, Router } from '@angular/router';
import { ApiService } from './../../../api.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-delete',
  templateUrl: './delete.component.html',
  styleUrls: ['./delete.component.css']
})
export class DeleteComponent implements OnInit {

  constructor(private apiservices: ApiService, private activatedRoute: ActivatedRoute, private router: Router) { }

  bookId!: Number
  failed!: String 
  page!: Number

  ngOnInit(): void {
    this.activatedRoute.paramMap.subscribe((param)=>{
      !Number(param.get('id')) ? this.router.navigate(['/books']) : this.bookId = Number(param.get('id'));
    })
    
    this.activatedRoute.queryParamMap.subscribe(param => {
      this.page = Number(param.get('page'))
    })
    
    this.deleteBook(this.bookId)

  }

  deleteBook(bookId: Number){

    this.apiservices.deleteBook(bookId).subscribe(res => {
      this.router.navigate(['/books'], {queryParams: {page: this.page}})
    }, err => {
        console.log(err)
        this.failed = "Unable to delete books"
    })
  }
}
