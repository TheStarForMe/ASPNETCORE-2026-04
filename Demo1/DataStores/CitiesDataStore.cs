using Demo1.DTO;

namespace Demo1.DataStores {
    public static class CitiesDataStore {
        public static List<CityDTO> Current { get; set; } = new List<CityDTO>();

        static CitiesDataStore() {
            Current = new List<CityDTO>() {
                new CityDTO{
                    ID = 1,
                    Name = "Tel-Aviv",
                    LandMarks = new List<LandMarkDTO>{
                        new LandMarkDTO {
                            ID = 1,
                            Name = "Azrieli Towers",
                            Description = "A complex of three skyscrapers"
                        },
                        new LandMarkDTO {
                            ID = 2,
                            Name = "Dizengoff Square",
                            Description = "A public square in the center of Tel-Aviv"
                        }
                    }},
                new CityDTO{
                    ID = 2,
                    Name = "Jerusalem",
                    LandMarks = new List<LandMarkDTO>{
                        new LandMarkDTO {
                            ID = 3,
                            Name = "Western Wall",
                            Description = "A wall in the Old City of Jerusalem"
                        },
                        new LandMarkDTO {
                            ID = 4,
                            Name = "Church of the Holy Sepulchre",
                            Description = "A church in the Old City of Jerusalem"
                        }
                    }
                },
            };
        }
    }
}
