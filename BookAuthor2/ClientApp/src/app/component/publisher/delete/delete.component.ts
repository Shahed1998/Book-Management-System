import { Router, ActivatedRoute } from '@angular/router';
import { ApiService } from 'src/app/api.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-delete',
  templateUrl: './delete.component.html',
  styleUrls: ['./delete.component.css']
})
export class DeleteComponent implements OnInit {

  publisherId!: number

  constructor(private apiservices: ApiService, private router: Router, private activatedRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.activatedRoute.paramMap.subscribe(param => {
      this.activatedRoute.paramMap.subscribe(param => {
        ! Number(param.get('id')) ? this.router.navigate(['/']) : this.publisherId = Number(param.get('id'))
        this.apiservices.deletePublisher(this.publisherId).subscribe(res => {
          this.router.navigate(['/publishers'], {queryParams: {page: 1}})
        }, err => {
          console.log(err);
        })  
      })
    })
  }

}
