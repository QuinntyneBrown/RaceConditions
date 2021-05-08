import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Player } from '../player';
import { PlayerService } from '../player.service';

@Component({
  selector: 'app-players',
  templateUrl: './players.component.html',
  styleUrls: ['./players.component.scss']
})
export class PlayersComponent {
  public players: Player[] = [];  
  public player: Player;
  public playerSelectControl: FormControl = new FormControl();  
  public playerForm: FormGroup = new FormGroup({
    name: new FormControl("", []),
    description: new FormControl("",[])
  });
  constructor(
    private readonly _playerService: PlayerService
  ) {  }

  ngOnInit(): void {
    this.getPlayers();
    this.subscribeToSelectionChanges();
  }

  public subscribeToSelectionChanges() {
    this.playerSelectControl.valueChanges
    .subscribe(x => {
      this.getPlayer()
    });
  }

  public getPlayers() {
    this._playerService.get()
    .subscribe(x => this.players = x);
  }

  public getPlayer() {
    this._playerService.getById({ playerId: this.playerSelectControl.value })
    .subscribe(x => {
      this.playerForm.patchValue({
        name: x.name,
        description: x.description
      })
    });
  }
}
