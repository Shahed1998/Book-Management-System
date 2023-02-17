import { ActivatedRoute } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { ApiService } from 'src/app/api.service';
import { faInfoCircle, faPenNib, faTrash } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-author',
  templateUrl: './author.component.html',
  styleUrls: ['./author.component.css']
})

export class AuthorComponent implements OnInit {

    authors: any;
    faInfo = faInfoCircle;
    faPenNib = faPenNib;
    faCross = faTrash;
    totalCount!: number; 
    page!: number;
    searchField!: string
    bookId!: number

    constructor(private apiservice: ApiService, private activatedRoute: ActivatedRoute) { }

    ngOnInit(): void {
      this.loadContent();
    }

    public loadContent()
    {
      this.activatedRoute.queryParamMap.subscribe(param => {
        this.page = Number(param.get('page'))
        this.getAllAuthors()
      })
    }

    public getAllAuthors()
    {
        this.apiservice.getAuthors({page:this.page, pageSize: 10, search: ''}).subscribe(res => {
          this.authors = res
          this.authors = this.authors.data
          this.totalCount = this.authors[0].count
        })
    }

    public search(){
      this.apiservice.getAuthors({page:this.page, pageSize: 10, search: this.searchField}).subscribe(res => {
        this.authors = res
        this.authors = this.authors.data
        // this.spinner = false
        // this.pageLoadSuccess = true;
      },
      err => {
        console.log(err);
        // this.pageLoadSuccess = false
        // this.spinner = false
      });
    }
}
