import { ActivatedRoute, Router } from '@angular/router';
import { ApiService } from 'src/app/api.service';
import { Component, OnInit } from '@angular/core';
import { faInfoCircle, faPenNib, faTrash } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-publisher',
  templateUrl: './publisher.component.html',
  styleUrls: ['./publisher.component.css']
})

export class PublisherComponent implements OnInit {

  publishers:any;
  spinner:boolean = true; // starts as true, when the data is loaded it gives false
  pageLoadSuccess:boolean = false; // gives true if the data is loaded else gives false
  faInfo = faInfoCircle;
  faPenNib = faPenNib;
  faCross = faTrash;
  searchField!: string
  page!: number;
  totalCount!: number

  constructor(private apiservice: ApiService, private activatedRoute:ActivatedRoute, private router:Router) {}

  ngOnInit(): void {

    this.activatedRoute.queryParamMap.subscribe(param => {
      ! Number(param.get('page')) ? this.router.navigate(['/']) : this.page = Number(param.get('page'))
      this.getAllPublishers();
    })
  }

  getAllPublishers()
  {
    this.apiservice.getAllPublishers({page:this.page, pageSize: 10, search: ''}).subscribe(res => {
      this.publishers = res
      this.publishers = this.publishers.data
      this.totalCount = this.publishers[0].count
      this.spinner = false
      this.pageLoadSuccess = true;
    },
    err => {
      console.log(err);
      this.pageLoadSuccess = false
      this.spinner = false
    });
  }

  // searches using the searchbox
  search(){
    this.apiservice.getAllPublishers({page:this.page, pageSize: 10, search: this.searchField}).subscribe(res => {
      this.publishers = res
      this.publishers = this.publishers.data
      this.spinner = false
      this.pageLoadSuccess = true;
    },
    err => {
      console.log(err);
      this.pageLoadSuccess = false
      this.spinner = false
    });
  }
}
