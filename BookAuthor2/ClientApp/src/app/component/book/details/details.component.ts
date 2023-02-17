import { Router, ActivatedRoute } from '@angular/router';
import { ApiService } from 'src/app/api.service';
import { Component, OnInit } from '@angular/core';
import { faInfoCircle } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})
export class DetailsComponent implements OnInit {

  book: any
  bookId!: Number
  genre: Array<String> = ["Fantasy", "Science", "Horror"];
  faInfo = faInfoCircle;

  // ------------------------------------- Book ----------------------------------------------
  bookTitle!: string;
  bookGenreType!: number;
  bookPublishedDate!: string;
  bookPublisherName!: string;
  bookPrice!: number;
  bookDescription!: string;
  bookAuthors: any;
  totalBookAuthors!: number; 

  constructor(private apiservice: ApiService, private router: Router, private activatedRoute: ActivatedRoute) { }

  ngOnInit(): void {

    this.activatedRoute.paramMap.subscribe((param)=>{
      !Number(param.get('id')) ? this.router.navigate(['/books']) : this.bookId = Number(param.get('id'));
    })
    this.GetBookDetails(this.bookId)
  }

  GetBookDetails(bookId: Number)
  {
    this.apiservice.getBookById(bookId).subscribe(res => {
      this.book = res
      this.bookTitle = this.book.data.title
      this.bookGenreType = this.book.data.type
      this.bookPublishedDate = this.book.data.publishedDate.split("T")[0]
      this.bookPublisherName = this.book.data.publisher.name
      this.bookPrice = this.book.data.price
      this.bookDescription = this.book.data.description
      this.bookAuthors = this.book.data.authors


      this.totalBookAuthors = this.bookAuthors.length
    }, err => {
      console.log(err)
      this.router.navigate(['/books'])
    })
  }

  GoToAuthorDetails(event: any)
  {
    this.router.navigate(["/author/details/"+event.target.value]);
  }

}
