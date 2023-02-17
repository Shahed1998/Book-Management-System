import { ApiService } from 'src/app/api.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Router } from '@angular/router';
import { HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit {

  authorId!: Number;
  author: any;
  authorName!: string
  authorDOB!: string 
  authorBio!: string
  bookId!: number
  spinner: boolean = false

  constructor(
    private apiservice: ApiService,
    private activatedRoute: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.activatedRoute.paramMap.subscribe((param)=>{
      !Number(param.get('id')) ? this.router.navigate(['/author/'+this.authorId]) : this.authorId = Number(param.get('id'));
    })

    this.getAuthorDetails(this.authorId)
  }

  public getAuthorDetails(id: Number){
    this.apiservice.getOnlyAuthorsById(id).subscribe(result => {
      this.author = result
      this.authorName = this.author.data.name
      this.authorDOB = this.author.data.dob.split('T')[0]
      this.authorBio = this.author.data.shortBio
      this.bookId = this.author.data.bookId == 0 ? null : this.author.data.bookId
    });
  }

  public EditAuthor(){
    this.spinner = true
    const data = {
      Id: this.authorId,
      Name: this.authorName,
      DOB: this.authorDOB,
      shortBio: this.authorBio,
      BookId: this.bookId
    }

    this.apiservice.editAuthor(data).subscribe(response => {
      this.author = response
      this.author.status == "success" ? alert("Updated successfully") : alert("Failed to update")
      this.spinner = false
      this.router.navigate(['/authors'], {queryParams: {page:1}})
    });
  }
}
