import { ActivatedRoute, Router } from '@angular/router';
import { ApiService } from 'src/app/api.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-info',
  templateUrl: './info.component.html',
  styleUrls: ['./info.component.css']
})
export class InfoComponent implements OnInit {

  publisher: any;
  publisherId!: number

  constructor(private apiService: ApiService, private activatedRoute: ActivatedRoute, private router: Router) { }

  ngOnInit(): void {
    this.activatedRoute.paramMap.subscribe(param => {
      this.publisherId = Number(param.get('id'))
      ! this.publisherId ? this.router.navigate(['/Error']) : this.getAuthorInfo(this.publisherId)

    })
  }

  getAuthorInfo(publisherId: number)
  {
    this.apiService.getPublisher(publisherId).subscribe(res => {
      this.publisher = res;
      this.publisher = this.publisher.data.name
    })
  }

}
